import { Color } from "./Color";
import { ProductSize } from "./ProductSize";
import { Report } from "./Report";
import { User } from "./SignUpUser";

export class CartSystem{

    public id:number;
    public name:string;
    public price:number;
    public image:string;
    public quantity:number;
    public report: Report = new Report();
    public productSize:ProductSize = new ProductSize();
    public colors:Color = new Color();
    public username: string;
    public applicationUser: User = new User();
}