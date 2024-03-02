import { useState, useEffect, useRef } from 'react';
import { Product } from '../../Models/Product';
import styles from './ProductTable.module.css';
import { FaSort, FaSortDown, FaSortUp } from 'react-icons/fa6';
import { Group } from '../../Models/Group';

interface ProductTableProps {
  onProductSelect: (product: Product) => void;
  products: Product[];
  selectedGroup: Group | null;
}

interface SortConfig {
  key: keyof Product | null;
  direction: 'ascending' | 'descending';
}

const ProductTable: React.FC<ProductTableProps> = ({ onProductSelect, products, selectedGroup }) => {
  const [sortedProducts, setSortedProducts] = useState<Product[]>([]);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [sortConfig, setSortConfig] = useState<SortConfig>({ key: null, direction: 'ascending' });

  useEffect(() => {
    const getSubgroupIds = (group: Group): number[] => {
      return group.subgroups ? group.subgroups.flatMap(subgroup => [subgroup.id, ...getSubgroupIds(subgroup)]) : [];
    };

    const selectedGroupIds = selectedGroup ? [selectedGroup.id, ...getSubgroupIds(selectedGroup)] : [];
    const filteredProducts = selectedGroup ? products.filter(product => selectedGroupIds.includes(product.groupId)) : products;
    setSortedProducts(filteredProducts);
  }, [selectedGroup, products]);

  useEffect(() => {
    function sortProducts() {
      const sortKey = sortConfig.key;
      if (sortKey) {
        const sorted = [...sortedProducts].sort((a, b) => {
          if (a[sortKey as keyof Product] < b[sortKey as keyof Product]) {
            return sortConfig.direction === 'ascending' ? -1 : 1;
          }
          if (a[sortKey as keyof Product] > b[sortKey as keyof Product]) {
            return sortConfig.direction === 'ascending' ? 1 : -1;
          }
          return 0;
        });
        setSortedProducts(sorted);
      }
    }
    sortProducts();
  }, [sortConfig, sortedProducts]);

  const requestSort = (key: keyof Product) => {
    let direction: 'ascending' | 'descending' = 'ascending';
    if (sortConfig.key === key && sortConfig.direction === 'ascending') {
      direction = 'descending';
    }
    setSortConfig({ key, direction });
  };

  const handleProductSelect = (product: Product) => {
    console.log("Product selected:", product); // Check if this logs correctly
    setSelectedProduct(product);
    onProductSelect(product);
  };

  const getSortIcon = (columnName: keyof Product) => {
    if (sortConfig.key === columnName) {
      return sortConfig.direction === 'ascending' ? <FaSortUp /> : <FaSortDown />;
    }
    return <FaSort />;
  };

  return (
    <div className={styles.tableContainer}>
      <table className={`${styles.customTable} ${styles.customTableStriped} ${styles.customTableBordered} ${styles.customTableHover}`}>
        <thead>
          <tr>
            <th onClick={() => requestSort('code')}>კოდი {getSortIcon('code')}</th>
            <th onClick={() => requestSort('name')}>დასახელება {getSortIcon('name')}</th>
            <th onClick={() => requestSort('price')}>ფასი {getSortIcon('price')}</th>
          </tr>
        </thead>
        <tbody>
          {sortedProducts.map(product => (
            <tr key={product.id} onClick={() => handleProductSelect(product)} style={selectedProduct?.id === product.id ? { fontWeight: 'bold' } : {}}>
              <td>{product.code}</td>
              <td>{product.name}</td>
              <td>₾ {product.price}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProductTable;