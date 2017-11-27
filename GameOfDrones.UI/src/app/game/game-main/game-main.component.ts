import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { GameService } from './../game.service';
import { Game } from './../../../models/Game';
import { Player } from './../../../models/Player';

@Component({
  providers: [ GameService ],
  selector: 'app-game-main',
  templateUrl: './game-main.component.html',
  styleUrls: ['./game-main.component.scss']
})
export class GameMainComponent implements OnInit, OnDestroy {
  currentGame: Game;

  constructor(private router: Router, private gameService: GameService) { }

  ngOnInit() {
    this.initPlayers();
  }
  ngOnDestroy() {
  }

  onSubmit() {
    this.gameService
      .newGame(this.currentGame)
      .subscribe(
        game => {
           this.currentGame = game.json();
           this.router.navigate(['Game/Round/:id', { id: this.currentGame.id }]);
        },
        error => {
          console.log(error);
       });
  }

  private initPlayers() {
    this.currentGame = new Game();
    this.currentGame.players = new Array<Player>();

    this.currentGame.players.push(new Player(1));
    this.currentGame.players.push(new Player(2));
  }

}
