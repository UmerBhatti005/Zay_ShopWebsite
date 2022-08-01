import { Category } from "./Category";
import { Color } from "./Color";
import { Gender } from "./Gender";
import { ProductImages } from "./ProductImages";
import { ProductSize } from "./ProductSize";
import { User } from "./SignUpUser";
import { Status } from "./Status";

export class Product{
    public id:number;
    public name:string;
    public description:string;
    public price:number;
    public isFeatured:boolean;
    public postedDate:Date;
    public quantity:number;
    public noofSales:number;
    public statuses:Status = new Status();
    public genders:Gender = new Gender();
    public categories:Category = new Category();
    public colors:Color = new Color();
    public productSizes:ProductSize = new ProductSize();
    public productImages:ProductImages[] = [];
    public username:string;
    public applicationUser: User = new User();
}