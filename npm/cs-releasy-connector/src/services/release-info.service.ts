import { BasicAuthentication, HttpService, JwtAuthentication } from '@chustasoft/cs-common'
import { ReleaseInfo } from '..';

export abstract class ReleaseInfoService {

    private httpService: HttpService;
    private apiUrl: string;


    constructor(authorizationApiUrl: string) {
        this.apiUrl = authorizationApiUrl;

        this.httpService = new HttpService();
    }


    public async getAll(): Promise<ReleaseInfo[]> {
        const authHeader = this.getAuthentication();

        return this.httpService.get<ReleaseInfo[]>(`${this.apiUrl}/release`, authHeader);
    }

    public async get(identifier: string): Promise<ReleaseInfo> {
        const authHeader = this.getAuthentication();

        return this.httpService.get<ReleaseInfo>(`${this.apiUrl}/release/${identifier}`, authHeader);
    }

    public async getFrom(filter: string | Date): Promise<ReleaseInfo[]> {
        const filterUrlPart = this.getFilterUrlPart(filter);
        const authHeader = this.getAuthentication();

        return this.httpService.get<ReleaseInfo[]>(`${this.apiUrl}/release/${filterUrlPart}/${filter}`, authHeader);
    }


    public abstract getAuthentication(): JwtAuthentication | BasicAuthentication;
    

    private getFilterUrlPart(filter: string | Date): string {
        if (filter instanceof Date)
            return `/from-date`;
        else
            return `/from-identifier`;
    }

}