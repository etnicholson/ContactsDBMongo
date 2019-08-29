import { PhoneDto } from './phoneDto';
import { EmailDto } from './emailDto';

export interface PersonDto {
    id: string;
    name: string;
    city: string;
    notes: string;
    phones: PhoneDto[];
    emails: EmailDto[];
}



