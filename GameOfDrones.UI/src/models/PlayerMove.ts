import { Player } from './Player';
import { Move } from './Move';

export class PlayerMove {
	gameId: number;
	roundId: number;
	moveId: number;
	playerId: string;

	player: Player;
	move: Move;

	constructor(player: Player) {
		this.player = player;
	}
}
