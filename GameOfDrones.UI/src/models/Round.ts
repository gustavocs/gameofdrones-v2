import { Player } from './Player';
import { PlayerMove } from './PlayerMove';

export class Round {
	roundId: number;
	number: number;
	gameId: string;
	moves: Array<PlayerMove>;
	winner: Player;

	constructor(gameId: string, number: number) {
		this.gameId = gameId;
		this.number = number;
		this.moves = new Array<PlayerMove>();
	}
}