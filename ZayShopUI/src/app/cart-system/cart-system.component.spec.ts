import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartSystemComponent } from './cart-system.component';

describe('CartSystemComponent', () => {
  let component: CartSystemComponent;
  let fixture: ComponentFixture<CartSystemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartSystemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartSystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
