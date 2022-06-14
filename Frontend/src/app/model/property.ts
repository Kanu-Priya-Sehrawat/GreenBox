import { IPropertyBase } from './ipropertybase';
import { Photo } from './Photo';

export class Property implements IPropertyBase {
    id: number;
    sellRent: number;
    name: string;
    plasticType: string;
    plasticTypeId: number;
    size: number;
    wt: number;
    quantity: number;
    photo?: string;
    estPossessionOn?: string;
    description?: string;
    photos?: Photo[];
}
