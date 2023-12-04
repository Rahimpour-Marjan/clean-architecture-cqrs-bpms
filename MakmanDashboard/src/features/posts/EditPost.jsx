import { FormLabel } from '../../components';
import POST_ITEM from '../../data/post-by-id.json';
import { usePost } from '../../hooks/usePost';
import { CreateEditPostForm } from './CreateEditPostForm';

export const EditPost = () => {
  // const { error, isLoading, post } = usePost();

  const { id, title, description, category, image } = POST_ITEM;

  return (
    <div>
      <FormLabel label='Edit post' />
      <CreateEditPostForm
        post={{
          postId: id,
          name: title,
          description,
          category: category.id,
          image,
        }}
      />
    </div>
  );
};
