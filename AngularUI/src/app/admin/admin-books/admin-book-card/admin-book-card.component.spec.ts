import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookCardComponent } from './admin-book-card.component';

describe('AdminBookCardComponent', () => {
  let component: AdminBookCardComponent;
  let fixture: ComponentFixture<AdminBookCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminBookCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminBookCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
