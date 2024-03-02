export interface Group {
    id:  number;
    name: string;
    parentGroupId:number | null;
    subgroups?: Group[];
}