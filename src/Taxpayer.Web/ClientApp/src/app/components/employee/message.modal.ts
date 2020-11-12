export interface MessageResponse<T> {
    statusCode: number;
    isSuccess: boolean;
    message: string;
    data: T;
    count: number;
    inconsistencies: Inconsistency[];
  }
  export interface Inconsistency {
    field: string;
    description: string;
  }