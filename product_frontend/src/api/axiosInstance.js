import axios from 'axios';

const API_GATEWAY_BASE_URL = 'http://localhost:5246'; 

const axiosInstance = axios.create({
  baseURL: API_GATEWAY_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

axiosInstance.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default axiosInstance;
