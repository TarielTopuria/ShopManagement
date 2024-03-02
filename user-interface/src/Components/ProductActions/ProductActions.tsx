import { useState } from "react";
import { FaPlus, FaPen, FaXmark, FaShare } from "react-icons/fa6";
import { useNavigate } from "react-router-dom";
import { ApiService } from "../../Api/ApiService";
import ConfirmationModal from "../../Modals/HelperModals/ConfirmationModal";
import AddProductModal from "../../Modals/ProductModals/AddProductModal";
import { Product } from "../../Models/Product";
import { ProductCreationModel } from "../../Models/ProductCreationModel";
import { ProductEditionModel } from "../../Models/ProductEditionModel";
import styles from "./ProductActions.module.css"
import { Country } from "../../Models/Country";
import { Group } from "../../Models/Group";

interface ProductActionsProps {
    selectedProduct: Product | null;
    onResetSelectedProduct: () => void;
    onProductsUpdated: () => void;
    countries: Country[];
    groups: Group[];
    products: Product[];
    selectedGroup: Group | null;
}

const ProductActions: React.FC<ProductActionsProps> = ({ selectedProduct, onResetSelectedProduct, onProductsUpdated, countries, groups, products, selectedGroup }) => {
    const [isAddProductModalOpen, setIsAddProductModalOpen] = useState(false);
    const [showConfirmationModal, setShowConfirmationModal] = useState(false);
    const navigate = useNavigate();

    const handleAddProduct = () => {
        onResetSelectedProduct();
        setIsAddProductModalOpen(true);
    };

    const handleSaveNewProduct = async (newProduct: ProductCreationModel) => {
        try {
            await ApiService.createProduct(newProduct);
            setIsAddProductModalOpen(false);
            onProductsUpdated();
        } catch (error) {
            console.error('Error creating product', error);
        }
    };

    const handleSaveEditedProduct = async (editedProduct: ProductEditionModel) => {
        if (selectedProduct) {
            try {
                await ApiService.editProduct(selectedProduct.id, editedProduct);
                setIsAddProductModalOpen(false);
                onProductsUpdated();
            } catch (error) {
                console.error('Error updating product', error);
            }
        }
    };

    const handleEditProduct = async () => {
        console.log("Edit product clicked", selectedProduct);
        console.log("Groups:", groups);
        if (selectedProduct) {
            setIsAddProductModalOpen(true);
        }
    };
    const handleDeleteProduct = () => {
        if (selectedProduct) {
            setShowConfirmationModal(true);
        }
    };

    const confirmDeletion = async () => {
        if (selectedProduct) {
            try {
                await ApiService.deleteProduct(selectedProduct.id);
                onResetSelectedProduct();
                onProductsUpdated();
            } catch (error) {
                console.error('Error deleting product', error);
            }
        }
        setShowConfirmationModal(false);
    };


    const cancelDeletion = () => {
        setShowConfirmationModal(false);
    };

    const handleDiagramBtn = () => {
        const getSubgroupIds = (group: Group): number[] => {
            return group.subgroups ? group.subgroups.flatMap(subgroup => [subgroup.id, ...getSubgroupIds(subgroup)]) : [];
        };

        const selectedGroupIds = selectedGroup ? [selectedGroup.id, ...getSubgroupIds(selectedGroup)] : [];
        const filteredProducts = selectedGroup ? products.filter(product => selectedGroupIds.includes(product.groupId)) : [];

        navigate('/chart', { state: { products: filteredProducts } });
    };

    return (
        <div className={styles.productActionBtn}>
            <button className={styles.productActionIcons} onClick={handleAddProduct}> <FaPlus /></button>
            <button className={styles.productActionIcons} onClick={handleEditProduct}> <FaPen /></button>
            <button className={styles.productActionIcons} onClick={handleDeleteProduct}> <FaXmark /></button>
            <div className={styles.rightActionBtns}>
                <button className={styles.diagramBtn} onClick={handleDiagramBtn}> დიაგრამა </button>
                <button className={styles.arrowBtn} onClick={handleDiagramBtn}> <FaShare /> </button>
            </div>
            {isAddProductModalOpen && (
                <AddProductModal
                    show={isAddProductModalOpen}
                    handleClose={() => setIsAddProductModalOpen(false)}
                    onSave={selectedProduct ? handleSaveEditedProduct : handleSaveNewProduct}
                    productForEdit={selectedProduct || undefined}
                    isEditMode={!!selectedProduct}
                    countries={countries}
                    groups={groups}
                />
            )}
            <ConfirmationModal
                show={showConfirmationModal}
                productName={selectedProduct ? selectedProduct.name : ''}
                onConfirm={confirmDeletion}
                onCancel={cancelDeletion}
            />
        </div>
    );
};


export default ProductActions;