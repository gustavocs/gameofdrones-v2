import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { GameService } from './../services/game.service';

import { Game } from './../../../models/Game';
import { Player } from './../../../models/Player';
import { Move } from './../../../models/Move';
import { Round } from './../../../models/Round';
import { PlayerMove } from './../../../models/PlayerMove';

@Component({
	selector: 'app-game-round',
	templateUrl: './game-round.component.html',
	styleUrls: ['./game-round.component.scss']
})
	export class GameRoundComponent implements OnInit {
	currentGame: Game;
	currentRound: Round;
	currentMove: Observable<PlayerMove>;
	currentPlayer: number;

	selectedMove: PlayerMove;

	gameId: string;

	constructor(
		private route: ActivatedRoute,
		private router: Router,
		private service: GameService) {
	}

	ngOnInit() {
		this.route.params.subscribe(params => {
			this.service.getGame(params['id'])
				.subscribe(game => {
					this.currentGame = game.json();
					this.setNewRound();
				});
		});
	}

	setNewRound() {

		if (!this.currentGame.rounds
					|| this.currentGame.rounds.length === 0) {
			this.currentRound = new Round(this.currentGame.gameId, 1);
		} else {
			this.currentRound = new Round(this.currentGame.gameId, this.currentGame.rounds.length + 1);
		}

		this.currentPlayer = 0;
		this.currentGame.rounds.push(this.currentRound);
		this.setNewMove();
	}

	selectMove(move: Move){
		const playerMove = this.currentRound.moves[this.currentRound.moves.length - 1];
		playerMove.moveId = move.moveId;
		playerMove.playerId = this.currentGame.players[this.currentPlayer - 1].playerId;
	}
	setNewMove() {
		this.currentPlayer++;
		this.currentMove = Observable.of(new PlayerMove(this.currentGame.players[this.currentPlayer - 1]));

		this.currentMove.subscribe(
			data => {
				this.currentRound.moves.push(data);
			});
	}

	finishRound(){
		this.service.postRound(this.currentRound)
			.subscribe(data => {
					const player: Player = data.json();
					if (player) {
						console.log(this.currentGame.players.find(g => g.playerId === player.playerId ));
						if (player.winner) {
							// finish game
						} else {
						this.setNewRound();
					} } else {
						// draw
					}
			});
	}

	onSubmit() {
		if (this.currentPlayer >= this.currentGame.players.length) {
			this.finishRound();
		} else {
			this.setNewMove();
		}
	}
}
