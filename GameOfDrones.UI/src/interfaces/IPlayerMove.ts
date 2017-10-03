import { IPlayer } from './IPlayer'
import { IMove } from './IMove'

export interface IPlayerMove {
	gameId: number;
	roundId: number;
	player: IPlayer;
	move: IMove;
}