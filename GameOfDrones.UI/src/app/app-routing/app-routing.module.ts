import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { GameMainComponent } from '../game/game-main/game-main.component';
import { GameRoundComponent } from '../game/game-round/game-round.component';
import { GameWinnerComponent } from '../game/game-winner/game-winner.component';

const routes: Routes =
[
	{ path: '', pathMatch: 'full', redirectTo: 'Game/New' },
	{ path: 'Game/New', pathMatch: 'full', component: GameMainComponent },
	{ path: 'Game/:id/Round', pathMatch: 'full', component: GameRoundComponent },
	{ path: 'Game/:id/Winner', pathMatch: 'full', component: GameWinnerComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
	declarations: []
})
export class RoutingModule { }
