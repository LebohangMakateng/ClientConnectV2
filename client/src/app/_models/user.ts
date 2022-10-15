import { Photo } from './photo';

export interface User {
    username: string
    token: string;
    roles: string[];
    id: number;
    photoUrl: string;
    city: string;
    biography: string;
    profession: string;
    country: string;
    photos: Photo[];
}

