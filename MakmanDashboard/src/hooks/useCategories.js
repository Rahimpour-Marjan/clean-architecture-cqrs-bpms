import { useQuery } from '@tanstack/react-query';
import { getCategories } from '../services/apiCategories';
import CATEGORIES from '../data/categories.json';

export const useCategories = () => {
  const {
    isLoading,
    data: categories,
    error,
  } = useQuery({
    queryKey: ['categories'],
    queryFn: getCategories,
    initialData: CATEGORIES,
  });

  return { isLoading, error, categories };
};
