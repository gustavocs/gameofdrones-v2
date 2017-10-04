import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { RoutingModule } from './app-routing/app-routing.module';

import { AppComponent } from './app.component';
import { TopNavComponent } from './top-nav/top-nav.component';
import { GameMainComponent } from './game/game-main/game-main.component';
import { GamePlayerComponent } from './game/game-player/game-player.component';
import { GameRoundComponent } from './game/game-round/game-round.component';

import { GameService } from './game/game.service';

@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
    GameMainComponent,
    GamePlayerComponent,
    GameRoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RoutingModule
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
