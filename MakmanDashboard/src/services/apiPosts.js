import { get, getById, deleteById } from './apiServices';
import POSTS_LIST from '../data/posts-list.json';
import POST_ITEM from '../data/post-by-id.json';
import { mockFetch } from '../utils/mockFetch';

export async function getPosts() {
  try {
    // const res = await get('post/crud');

    const res = await mockFetch(POSTS_LIST);

    return res.results;
  } catch (error) {
    console.log(error);
  }
}

export async function getPost(id) {
  // const res = await getById('post/crud', id);

  const res = await mockFetch(POST_ITEM);

  return res;
}

export async function createEditPost(newPost, postId) {
  // const res = await getById('post/crud', id);

  const res = await mockFetch({});
}

export async function deletePost(postId) {
  // const res = await deleteById('post/crud', id);
  const res = await mockFetch({});
}
