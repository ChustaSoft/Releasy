import { BasicAuthentication } from '@chustasoft/cs-common';
import { ReleaseInfo } from '..';
export declare abstract class ReleaseInfoService {
    private httpService;
    private apiUrl;
    constructor(authorizationApiUrl: string);
    getAll(): Promise<ReleaseInfo[]>;
    get(identifier: string): Promise<ReleaseInfo>;
    getFrom(filter: string | Date): Promise<ReleaseInfo[]>;
    abstract getAuthentication(): string | BasicAuthentication;
    private getFilterUrlPart;
}
