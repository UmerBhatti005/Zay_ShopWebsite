import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartSystemAdminPannelComponent } from './cart-system-admin-pannel.component';

describe('CartSystemAdminPannelComponent', () => {
  let component: CartSystemAdminPannelComponent;
  let fixture: ComponentFixture<CartSystemAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartSystemAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartSystemAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
