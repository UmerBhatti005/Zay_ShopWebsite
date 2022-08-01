import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModalAdminPannelComponent } from './product-modal-admin-pannel.component';

describe('ProductModalAdminPannelComponent', () => {
  let component: ProductModalAdminPannelComponent;
  let fixture: ComponentFixture<ProductModalAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductModalAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductModalAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
