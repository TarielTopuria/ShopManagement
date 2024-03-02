import axios from 'axios';
import { Group } from '../Models/Group';
import { Product } from '../Models/Product';
import { Country } from '../Models/Country';
import { GroupCreationModel } from '../Models/GroupCreationModel';
import { GroupEditionModel } from '../Models/GroupEditionModel';
import { ProductEditionModel } from '../Models/ProductEditionModel';
import { ProductCreationModel } from '../Models/ProductCreationModel';
import { CountryCreationModel } from '../Models/CountryCreationModel';

const API_URL = 'https://localhost:7241/api';

export class ApiService {
  static async getCountries(): Promise<Country[]> {
    try {
      const response = await axios.get<Country[]>(`${API_URL}/Countries`);
      return response.data;
    } catch (error) {
      console.error('Error fetching countries:', error);
      return [];
    }
  };

  static async createCountry(countryData: CountryCreationModel): Promise<Country> {
    try {
      const response = await axios.post<Country>(`${API_URL}/Countries/createCountry`, countryData);
      return response.data;
    } catch (error) {
      console.error('Error creating country', error);
      throw error;
    }
  }

  static async getProducts(): Promise<Product[]> {
    try {
      const response = await axios.get<Product[]>(`${API_URL}/Products`);
      return response.data;
    } catch (error) {
      console.error('Error fetching products', error);
      return[];
    }
  }

  static async createProduct(productData: ProductCreationModel): Promise<Product> {
    try {
      const response = await axios.post<Product>(`${API_URL}/Products/createProduct`, productData);
      return response.data;
    } catch (error) {
      console.error('Error creating product', error);
      throw error;
    }
  }

  static async editProduct(id: number, productData: ProductEditionModel): Promise<void> {
    try {
      await axios.put(`${API_URL}/Products/${id}`, productData);
    } catch (error) {
      console.error('Error updating product', error);
      throw error;
    }
  }

  static async deleteProduct(id: number): Promise<void> {
    try {
      await axios.delete(`${API_URL}/Products/${id}`);
    } catch (error) {
      console.error('Error deleting product', error);
      throw error;
    }
  }

  static async getGroups(): Promise<Group[]>  {
    try {
      const response = await axios.get<Group[]>(`${API_URL}/Groups`);
      return response.data;
    } catch (error) {
      console.error('Error fetching groups', error);
      return [];
    }
  }

  static async createGroup(groupData: GroupCreationModel): Promise<Group> {
    try {
      const response = await axios.post<Group>(`${API_URL}/Groups/createGroup`, groupData);
      return response.data;
    } catch (error) {
      console.error('Error creating group', error);
      throw error;
    }
  }

  static async editGroup(id: number, groupData: GroupEditionModel): Promise<void> {
    try {
      await axios.put(`${API_URL}/Groups/${id}`, groupData);
    } catch (error) {
      console.error('Error updating group', error);
      throw error;
    }
  }

  static async deleteGroup(id: number): Promise<void> {
    try {
      await axios.delete(`${API_URL}/Groups/${id}`);
    } catch (error) {
      console.error('Error deleting group', error);
      throw error;
    }
  }
}
