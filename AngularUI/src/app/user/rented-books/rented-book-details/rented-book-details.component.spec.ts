import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentedBookDetailsComponent } from './rented-book-details.component';

describe('RentedBookDetailsComponent', () => {
  let component: RentedBookDetailsComponent;
  let fixture: ComponentFixture<RentedBookDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RentedBookDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RentedBookDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
