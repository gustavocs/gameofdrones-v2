import { IGame } from './../interfaces/IGame';
import { IPlayer } from './../interfaces/IPlayer';
import { IRound } from './../interfaces/IRound';

export class Game implements IGame
{
	id: string;
    players: Array<IPlayer>;
	rounds: Array<IRound>;
	winner: IPlayer;
}