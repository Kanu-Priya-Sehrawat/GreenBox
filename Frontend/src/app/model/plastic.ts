import { Photo } from './Photo';

export class Plastic{
    id: number;
    name: string;
    plasticType: string;
    plasticTypeId: number;
    wt: number;
    quantity: number;
    photo?: string;
    estPossessionOn?: string;
    description?: string;
    photos?: Photo[];
}
