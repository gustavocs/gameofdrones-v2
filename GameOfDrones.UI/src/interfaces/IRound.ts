import { IPlayer } from './IPlayer'
import { IPlayerMove } from './IPlayerMove'

export interface IRound {
	id: number;
	gameId: number;
	moves: Array<IPlayerMove>;
	winner: IPlayer;
}