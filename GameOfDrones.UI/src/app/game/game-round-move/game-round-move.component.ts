import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import { GameService } from './../services/game.service';
import { Game } from './../../../models/Game';
import { Round } from './../../../models/Round';
import { GameConfig } from './../../../models/GameConfig';
import { Player } from './../../../models/Player';
import { Move } from './../../../models/Move';
import { PlayerMove } from './../../../models/PlayerMove';

@Component({
	providers: [ GameService ],
	selector: 'app-game-round-move',
	templateUrl: './game-round-move.component.html',
	styleUrls: ['./game-round-move.component.scss']
})
export class GameRoundMoveComponent implements OnInit {
	gameConfig: GameConfig;
	selectedMove: Move;
	moves: Observable<Array<Move>>;

	@Input()
	currentMove: PlayerMove;

	@Output()
	selectedMoveUpdate: EventEmitter<PlayerMove> = new EventEmitter<PlayerMove>();

	constructor(private service: GameService) { }

	ngOnInit() {
		this.moves = this.service.getConfig()
			.switchMap(res => Observable.from(res.json().moves))
			.toArray<Move>();
	}
	onModelChange(selectedMove: any){
		this.selectedMoveUpdate.emit(selectedMove);
	}


}
