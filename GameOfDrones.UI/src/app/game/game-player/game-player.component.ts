import { Component, OnInit, Input } from '@angular/core';

import { Player } from './../../../models/Player';

@Component({
  selector: 'app-game-player',
  templateUrl: './game-player.component.html',
  styleUrls: ['./game-player.component.scss']
})
export class GamePlayerComponent implements OnInit {
  @Input()
  player: Player;

  constructor() { }

  ngOnInit() {
  }

}
