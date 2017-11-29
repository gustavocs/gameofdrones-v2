import { Player } from './Player';
import { Move } from './Move';

export class PlayerMove {
	gameId: number;
	roundId: number;
	moveId: number;
	playerId: string;

	player: Player;
	move: Move;
	constructor(player: Player, roundId?: number, playerId?: string, moveId?: number) {
		this.player = player;

		this.roundId = roundId;
		this.playerId = playerId;
		this.moveId = moveId;
	 }
}
