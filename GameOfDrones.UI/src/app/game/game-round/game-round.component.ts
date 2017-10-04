import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'Rxjs/Observable';
import { GameService } from './../game.service';

import { Game } from './../../../models/Game';

@Component({
  selector: 'app-game-round',
  templateUrl: './game-round.component.html',
  styleUrls: ['./game-round.component.scss']
})
export class GameRoundComponent implements OnInit {
  currentGame: Game;
  gameId: string;
  roundNumber: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: GameService) { }

  ngOnInit() {
      this.route.params.subscribe(params => {
        this.service.getGame(params['id'])
          .subscribe(game => {
              this.currentGame = game.json();
              this.roundNumber =
                (!this.currentGame.rounds) ? 1 : this.currentGame.rounds.length + 1;
             });
    });
  }

}
