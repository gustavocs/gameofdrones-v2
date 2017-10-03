import { IPlayer } from './../interfaces/IPlayer';

export class Player implements IPlayer
{
	constructor(number: number) {
        this.number = number;
    }

	id: string;
    number: number;
	name: string;
	winner: boolean;
}