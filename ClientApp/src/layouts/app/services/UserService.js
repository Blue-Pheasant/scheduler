import { JwtInterceptor } from '../../../services/JwtInterceptor';

export class UserService {
    constructor() {
      this.interceptor = new JwtInterceptor();
    }

    logout = async () => {
      const res = await this.interceptor.post('/api/auth/logout');
      
      if (!res.ok) {
        const responseJson = await res.json();
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }

    getInfo = async () => {
      const res = await this.interceptor.get('/api/user/info')

      if (!res.ok) {
        const responseJson = await res.json();
        console.log(responseJson);
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }

    getProfile = async () => {
      const res = await this.interceptor.get('/api/user/profile')
      
      if (!res.ok) {
        const responseJson = await res.json();
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }

    updateProfile = async () => {
      const res = await this.interceptor.patch('/api/user/profile')
      
      if (!res.ok) {
        const responseJson = await res.json();
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }

    getUsers = async () => {
      const res = await this.interceptor.patch('/api/user/list')
      
      if (!res.ok) {
        const responseJson = await res.json();
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }

    getUser = async (email) => {
      const res = await this.interceptor.patch('/api/user/list', { email: email })
      
      if (!res.ok) {
        const responseJson = await res.json();
        throw new Error(JSON.stringify(responseJson));
      }
        
      const data = await res.json();
      return data;
    }
}