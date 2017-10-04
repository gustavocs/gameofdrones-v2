import { IPlayer } from './IPlayer';
import { IRound } from './IRound';

export interface IGame {
	id: string;
    players: Array<IPlayer>;
	rounds: Array<IRound>;
	winner: IPlayer;
}