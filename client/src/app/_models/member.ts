import { Photo } from './photo';

export interface Member {
    id: number;
    userName: string;
    photoUrl: string;
    city: string;
    country: string;
    photos: Photo[];
  }

