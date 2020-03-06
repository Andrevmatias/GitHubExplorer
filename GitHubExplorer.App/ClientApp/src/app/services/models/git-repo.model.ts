import { GitUser } from "./git-user.model";

export interface GitRepo {
  id: number;
  name: string;
  description: string;
  starCount: number;
  author: GitUser;
  openIssuesCount: number;
  mainProgrammingLanguage: string;
  creationDate: Date;
  isFavorite: boolean;
}
