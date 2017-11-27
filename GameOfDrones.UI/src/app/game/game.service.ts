import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Game } from './../../models/Game';
import { WEB_API } from './../../config/Constants';

@Injectable()
export class GameService {

  constructor(private http: Http) {   }

  public getGame(gameId: string): Observable<any> {
    return this.http
      .get(WEB_API.GAME, gameId)
      .take(1);
  }
  public newGame(game: Game): Observable<any> {
    return this.http
      .post(WEB_API.GAME, game)
      .take(1);
  }


}
