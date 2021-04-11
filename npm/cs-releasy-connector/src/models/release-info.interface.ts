export interface ReleaseInfo {    
    identifier: string;
    date: Date;
    additions: string[];
    changes: string[];
    deprecations: string[];
    eliminated: string[];
    fixes: string[];
    secured: string[];
}