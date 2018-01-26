import { Player } from './Player';
import { Round } from './Round';

export class Game {
	gameId: string;
	players: Array<Player>;
	rounds: Array<Round>;
	winner: Player;
}