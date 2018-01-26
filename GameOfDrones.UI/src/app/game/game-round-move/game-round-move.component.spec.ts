import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameRoundMoveComponent } from './game-round-move.component';

describe('GameRoundMoveComponent', () => {
  let component: GameRoundMoveComponent;
  let fixture: ComponentFixture<GameRoundMoveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameRoundMoveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameRoundMoveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
