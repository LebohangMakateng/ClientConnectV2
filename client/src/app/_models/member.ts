import { Photo } from './photo';

export interface Member {
    id: number;
    userName: string;
    photoUrl: string;
    city: string;
    biography: string;
    profession: string;
    country: string;
    photos: Photo[];
  }

