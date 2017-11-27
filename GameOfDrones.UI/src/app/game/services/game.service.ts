import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Round } from './../../../models/Round';
import { Game } from './../../../models/Game';
import { GameConfig } from './../../../models/GameConfig';

import { WEB_API } from './../../../config/Constants';

@Injectable()
export class GameService {

	constructor(private http: Http) {   }

	public getGame(gameId: string): Observable<any> {
		return this.http
			.get(WEB_API.GAME + gameId)
			.take(1);
	}

	public newGame(game: Game): Observable<any> {
		return this.http
			.post(WEB_API.GAME, game)
			.take(1);
	}

	public getConfig(): Observable<any> {
			return this.http
				.get(WEB_API.CONFIG)
				.take(1);
	}

	public updateConfig(config: GameConfig): Observable<any> {
		return this.http
			.post(WEB_API.CONFIG, config)
			.take(1);
	}

	public postRound(round: Round): Observable<any> {
		return this.http
			.post(WEB_API.ROUND, round)
			.take(1);
	}
}
