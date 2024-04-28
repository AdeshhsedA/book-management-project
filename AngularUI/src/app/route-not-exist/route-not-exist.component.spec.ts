import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RouteNotExistComponent } from './route-not-exist.component';

describe('RouteNotExistComponent', () => {
  let component: RouteNotExistComponent;
  let fixture: ComponentFixture<RouteNotExistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RouteNotExistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RouteNotExistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
