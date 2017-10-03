import { Component, OnInit } from '@angular/core';
import { Game } from './../../../models/Game';
import { Player } from './../../../models/Player';

@Component({
  selector: 'app-game-main',
  templateUrl: './game-main.component.html',
  styleUrls: ['./game-main.component.scss']
})
export class GameMainComponent implements OnInit {
  currentGame: Game;

  constructor() { }

  ngOnInit() {
    this.initPlayers();
  }

  onSubmit(){
    console.log('fdfsdfds');
  }

  private initPlayers(){
    this.currentGame = new Game();
    this.currentGame.players = new Array<Player>();

    this.currentGame.players.push(new Player(1));
    this.currentGame.players.push(new Player(2));
  }

}
