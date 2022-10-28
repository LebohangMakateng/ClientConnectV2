export interface Rating {
    id: number;
    senderId: number;
    senderUsername: string;
    senderPhotoUrl: string;
    recipientId: number;
    recipientUsername: string;
    recipientPhotoUrl: string;
    content: string;
    score: number;
    scoreAvg: number;
    dateRead?: Date;
    ratingSent: Date; 
}
