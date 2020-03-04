export interface Page<T> {
  items: T[];
  number: number;
  totalItems: number;
  totalPages: number;
  isLast: boolean;
}
