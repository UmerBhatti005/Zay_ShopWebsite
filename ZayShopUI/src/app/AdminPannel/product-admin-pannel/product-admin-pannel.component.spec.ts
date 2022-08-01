import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAdminPannelComponent } from './product-admin-pannel.component';

describe('ProductAdminPannelComponent', () => {
  let component: ProductAdminPannelComponent;
  let fixture: ComponentFixture<ProductAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
