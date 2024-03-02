export interface ProductCreationModel{
    code: string;
    name: string;
    price: number;
    startDate: Date;
    endDate: Date;
    countryId: number;
    groupId: number | undefined;
}