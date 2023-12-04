import CATEGORIES from '../data/categories.json';
import { mockFetch } from '../utils/mockFetch';

export async function getCategories() {
  try {
    // const res = await get('category');

    const res = await mockFetch(CATEGORIES);

    return res;
  } catch (error) {
    console.log(error);
  }
}
