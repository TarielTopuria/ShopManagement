import React, { useEffect, useState } from 'react';
import { Product } from '../../Models/Product';
import './ChartComponent.css';
import { useLocation } from 'react-router-dom';

const ChartComponent: React.FC = () => {
    const [datesArray, setDatesArray] = useState<string[]>([]);
    const location = useLocation();
    const products = location.state?.products as Product[] || [];

    useEffect(() => {
        const today = new Date();
        const currentYear = today.getFullYear();
        const currentMonth = today.getMonth();
        const lastDayOfMonth = new Date(currentYear, currentMonth + 1, 0).getDate();
        const startDay = Math.max(lastDayOfMonth - 7, 1);

        const tempDatesArray = [];
        for (let day = startDay; day <= lastDayOfMonth; day++) {
            const date = new Date(currentYear, currentMonth, day);
            const formattedDate = date.toLocaleDateString('en-GB');
            tempDatesArray.push(formattedDate);
        }
        setDatesArray(tempDatesArray);
    }, []);

    const isProductActiveOnDay = (product: Product, date: string): boolean => {
        // Convert startDate and endDate to the same format as datesArray
        const formattedStartDate = new Date(product.startDate).toLocaleDateString('en-GB');
        const formattedEndDate = new Date(product.endDate).toLocaleDateString('en-GB');
    
        return date >= formattedStartDate && date <= formattedEndDate;
    };      

    return (
        <div className="chart-container">
            <table>
                <thead>
                    <tr>
                        <th>Product</th>
                        {datesArray.map(date => (
                            <th key={date}>{date}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {products.map(product => (
                        <tr key={product.id}>
                            <td>{product.name}</td>
                            {datesArray.map(date => (
                                <td key={date} className={isProductActiveOnDay(product, date) ? 'active' : ''}></td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ChartComponent;
