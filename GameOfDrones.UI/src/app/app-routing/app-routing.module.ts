import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { GameMainComponent } 
    from '../game/game-main/game-main.component';

const routes: Routes =
[
  {path: '', pathMatch: 'full', component: GameMainComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})
export class RoutingModule { }
