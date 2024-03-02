import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import GroupList from './GroupLists/GroupList';
import ProductTable from './ProductTable/ProductTable';
import GroupActions from './GroupActions/GroupActions';
import ProductActions from './ProductActions/ProductActions';
import { Group } from '../Models/Group';
import { Product } from '../Models/Product';
import { ApiService } from '../Api/ApiService';
import { Country } from '../Models/Country';

const MainPage: React.FC = () => {
  const [selectedGroup, setSelectedGroup] = useState<Group | null>(null);
  const [selectedParentGroup, setSelectedParentGroup] = useState<Group | null>(null);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [products, setProducts] = useState<Product[]>([]);
  const [countries, setCountries] = useState<Country[]>([]);
  const [groups, setGroups] = useState<Group[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const fetchedCountries = await ApiService.getCountries();
      setCountries(fetchedCountries);
      const fetchedGroups = await ApiService.getGroups();
      setGroups(fetchedGroups);
      refreshProducts();
    };

    fetchData();
  }, []);

  useEffect(() => {
    refreshProducts();
  }, []);

  const handleGroupSelect = (group: Group) => {
    setSelectedGroup(group);
  };

  const handleProductSelect = (product: Product) => {
    setSelectedProduct(product);
  };

  const resetSelectedProduct = () => {
    setSelectedProduct(null);
  };

  const refreshProducts = async () => {
    try {
        const fetchedProducts = await ApiService.getProducts();
        setProducts(fetchedProducts);
    } catch (error) {
        console.error('Error fetching products', error);
    }
};
  const refreshGroups = async () => {
    const fetchedGroups = await ApiService.getGroups();
    setGroups(fetchedGroups);
  };

  return (
    <Container fluid>
      <Row>
        <Col sm={3} className="sidebar">
        <GroupActions 
            selectedGroup={selectedGroup} 
            groups={groups} 
            onGroupsUpdated={refreshGroups}
          />
          <GroupList groups={groups} onGroupSelect={handleGroupSelect} />
        </Col>
        <Col sm={9} className="product-table ps-0">
          <ProductActions
            selectedProduct={selectedProduct}
            onResetSelectedProduct={resetSelectedProduct}
            onProductsUpdated={refreshProducts}
            countries={countries}
            groups={groups}
            products={products}
            selectedGroup={selectedGroup}
          />
          <ProductTable
            onProductSelect={handleProductSelect}
            products={products}
            selectedGroup={selectedGroup}
          />
        </Col>
      </Row>
    </Container>
  );
};

export default MainPage;
