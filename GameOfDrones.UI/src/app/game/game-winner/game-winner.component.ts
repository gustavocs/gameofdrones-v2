import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { GameService } from './../services/game.service';
import { Player } from '../../../models/Player';

@Component({
  selector: 'app-game-winner',
  templateUrl: './game-winner.component.html',
  styleUrls: ['./game-winner.component.scss']
})
export class GameWinnerComponent implements OnInit {

  private winnerPlayer: Player;

  constructor(
		private route: ActivatedRoute,
		private router: Router,
		private service: GameService) {
	}

	ngOnInit() {
		this.route.params.subscribe(params => {
			this.service.getGame(params['id'])
				.subscribe(game => {
					this.winnerPlayer = game.json().players.find(p => p.winner);
				});
		});
	}

}
