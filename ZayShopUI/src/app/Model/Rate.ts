import { Product } from "./Product";

export class Rate {

    public id: number;
    public rating: number;
    public productId: number;
    public products: Product = new Product();
}